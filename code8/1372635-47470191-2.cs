    public void JustifyParagraph(Control _ctl)
    {
       // Controls with a .Text ptoperty - filter those you care about
       if ((_ctl.GetType() != typeof(Label)) && (_ctl.GetType() != typeof(TextBox)))
          return;
    
       Font _font = _ctl.Font;
       int _ctl_width = _ctl.ClientSize.Width;
       string _result = String.Empty;
    
       // Split text in paragraphs
       List<string> _paragraphs = new List<string>();
       _paragraphs.AddRange(_ctl.Text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList());
    
       // Justify each paragraph
       foreach (string _paragraph in _paragraphs)
       {
          string _line = string.Empty;
          int _par_width = TextRenderer.MeasureText(_paragraph, _font).Width;
    
          if (_par_width > _ctl_width)
          {
             // Get all paragraph words, add a normal space and calculate
             // when their sum exceeds the constraints
             string[] _Words = _paragraph.Split(' ');
             _line = _Words[0] + (char)32;
             for (int x = 1; x < _Words.Length; x++)
             {
                string _tmpline = _line + (_Words[x] + (char)32);
                if (TextRenderer.MeasureText(_tmpline, _font).Width > _ctl_width)
                {
                   // Max lenght reached. Justify the line and step back
                   _result += Justify(_line.TrimEnd(), _font, _ctl_width) + "\r\n";
                   _line = string.Empty;
                   --x;
                } else {
                   // Some capacity still left
                   _line += (_Words[x] + (char)32);
                }
             }
             // Adds the remainder if any
             if (_line.Length > 0)
                _result += _line + "\r\n";
          }
          else
          {
             // This line is less than its constraint
             _result += _paragraph + "\r\n";
          }
       }
       _ctl.Text = _result.Substring(0, _result.Length - 2); // Cuts the last linefeed
    }
