    public class CustomMapper : EncoderFallback
    {
       // Use can override the "replacement character", so track what they
       // give us.
       public string DefaultString;
       public CustomMapper() : this("*")
       {   
       }
       public CustomMapper(string defaultString)
       {
          this.DefaultString = defaultString;
       }
       public override EncoderFallbackBuffer CreateFallbackBuffer()
       {
          return new CustomMapperFallbackBuffer(this);
       }
       // This is the length of the largest possible replacement string we can
       // return for a single Unicode code point.
       public override int MaxCharCount
       {
          get { return 2; }
       } 
    }
    public class CustomMapperFallbackBuffer : EncoderFallbackBuffer
    {
       CustomMapper fb; 
       public CustomMapperFallbackBuffer(CustomMapper fallback)
       {
          // We can use the same custom buffer with different fallbacks, e.g.
          // we might have different sets of replacement characters for different
          // cases. This is just a reference to the parent in case we want it.
          this.fb = fallback;
       }
       public override bool Fallback(char charUnknown, int index)
       {
          // Do the work of figuring out what sequence of characters should replace
          // charUnknown. index is the position in the original string of this character,
          // in case that's relevant.
          // If we end up generating a sequence of replacement characters, return
          // true, and the encoder will start calling GetNextChar. Otherwise return
          // false.
       }
       public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index)
       {
          // Same as above, except we have a UTF-16 surrogate pair. Same rules
          // apply: if we can map this pair, return true, otherwise return false.
          // Most likely, you're going to return false here for an ASCII-type
          // encoding.
       }
       public override char GetNextChar()
       {
          // Return the next character in our internal buffer of replacement
          // characters waiting to be put into the encoded byte stream. If
          // we're all out of characters, return '\u0000'.
       }
       public override bool MovePrevious()
       {
          // Back up to the previous character we returned and get ready
          // to return it again. If that's possible, return true; if that's
          // not possible (e.g. we have no previous character) return false;
       }
       public override int Remaining 
       {
          // Return the number of characters that we've got waiting
          // for the encoder to read.
          get { return count < 0 ? 0 : count; }
       }
       public override void Reset()
       {
           // Reset our internal state back to the initial one.
       }
    }
