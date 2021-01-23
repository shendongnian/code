    public class LetterExtension<T> : LetterValue, IEquatable<LetterExtension<T>> {
    	public T Extension { get; set; }
    	
    	public LetterExtension(char c, T extension) : base(c) {
    		this.Extension = extension;
    	}
    
    	public override string ToString() => $"{Letter} {Extension}";
    	
    	public bool Equals(LetterExtension<T> other) => 
            Letter == other.Letter && Extension.Equals(other.Extension);
    }
