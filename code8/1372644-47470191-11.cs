    textBox1.Text = JustifyLines(textBox1.Text, textBox1.Font, textBox1.ClientSize.Width);
    public string JustifyLines(string _text, Font _font, int _ctl_width)
    {
       string _result = "";
    
       // Split text in paragraphs
       List<string> _paragraphs = new List<string>();
    	_paragraphs.AddRange(_text.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList());
    
       // Justify each paragraph and re-insert a linefeed
       foreach (string _paragraph in _paragraphs)
       {
    			_result += Justify(_paragraph, _font, _ctl_width) + "\r\n";
       }
    
       return _result.Substring(0, _result.Length -2); // Cuts the last linefeed
    }
    
