    public void JustifyLines(Control _ctl)
    {
       // Controls with a .Text property - filter those you care about
       if ((_ctl.GetType() != typeof(Label)) && (_ctl.GetType() != typeof(TextBox)))
          return;
    
       Font _font = _ctl.Font;
       int _width = _ctl.ClientSize.Width;
       string _result = "";
    
       // Split text in paragraphs
       List<string> _paragraphs = new List<string>();
       _paragraphs.AddRange(_ctl.Text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList());
    
       // Justify each paragraph and re-insert a linefeed
       foreach (string _paragraph in _paragraphs)
       {
          _result += Justify(_paragraph, _font, _width) + "\r\n";
       }
    
       _ctl.Text =_result.Substring(0, _result.Length -2); // Cuts the last linefeed
    }
    
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
       int _avgspace = ((_width - _WordsWidth) / _num_words);
       // Adjust the calculated space to the width of the actual space char in use
       _avgspace = (int)(_avgspace / _spacecharwidth);
       //Remainder 
       float _adjustspace = (_width - (_WordsWidth + (_avgspace * _num_words))) / _spacecharwidth;
    
       // Builds a "Spacer" string using "_spacechar"
       string _spaces = ((Func<string>)(() =>
       {
          string _res = "";
          for (int h = 0; h < _avgspace; h++)
             _res += _spacechar;
          return _res;
       })) ();
    
       // Add spaces to all words (cuts the trailing)
       return ((Func<string>)(() =>
       {
          string _res = "";
          foreach (string _word in _Words)
          {
             _res += _word + _spaces;
             if (_adjustspace > 1)	//Adjust the spacing if there's a reminder
             {
                _res += _spacechar;
                --_adjustspace;
             }
          }
          return _res.TrimEnd();
       }))();
    }
