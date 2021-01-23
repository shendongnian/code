    private string Justify(string _text, Font _font, int _width)
    {
       char _spacechar = (char)0x200A;
       // Extract all text words.
       List<string> _Words = _text.Split(' ').ToList();
       if (_Words.Capacity < 2)
          return _text;
    
       int _num_words = _Words.Capacity - 1;
    
       // Overall width of words and width of hairspace
       int _WordsWidth = TextRenderer.MeasureText(_text.Replace(" ", ""), _font).Width;
       int _spacecharwidth = TextRenderer.MeasureText(_Words[0] + _spacechar, _font).Width
                           - TextRenderer.MeasureText(_Words[0], _font).Width;
    
      // Calculate the average spacing between each word minus the last one 
      int _avgspace = ((_width - _WordsWidth) / _num_words) / _spacecharwidth;
      //Remainder 
      float _adjustspace = (_width - (_WordsWidth + (_avgspace * _num_words * _spacecharwidth)));
      // Add spaces to all words
      return ((Func<string>)(() =>
      {
         string _spaces = "";
         string _adjustedwords = "";
         // Builds a "Spacer" string using "_spacechar"
         for (int h = 0; h < _avgspace; h++)
            _spaces += _spacechar;
         foreach (string _word in _Words)
         {
            _adjustedwords += _word + _spaces;
            //Adjust the spacing if there's a reminder
            if (_adjustspace > 0)
            {
               _adjustedwords += _spacechar;
               _adjustspace -= _spacecharwidth;
            }
         }
         return _adjustedwords.TrimEnd();
      }))();
    }
