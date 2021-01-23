    namespace Acircalipse.MenuClasses
    {
        public class TextBox:MenuItem
        {
            private string originTitle;
        public string Text
        {
        get
        {
        return title.Replace(originTitle, "").Replace(Menu.separator, "");
        }
        }
        public int index, max;
    
        public      TextBox     (string Title, string text = "", int MaxCharacters = 14)
        {
        originTitle = Title;
        index = 0;
        max = MaxCharacters;
        SetText(text);
        }
        public void     SetText     (string text)
        {
        if (text.Length > max) text = text.Substring(0, max);
        title = originTitle + Menu.separator + text;
        }
        
        public void     ChangeIndex     (int howMuch)
        {
        index += howMuch;   
        ChangeCar(index);
        }
        public void     AddChar     (int index = 0)
        {
        SetText(Text + Menu.Wheel(index));
        }
        public void     ChangeCar       (int index)
        {
        if(Text.Length > 0)
        SetText(Text.Substring(0, Text.Length - 1) + Menu.Wheel(index));
        }
        public void     DeleteChar      ()
        {
        if (Text.Length > 0)
        SetText(Text.Substring(0, Text.Length - 1));
        }
        }
    }
Where the Menu.Wheel(int index) is simply an array of available character for user to type in
    public static char Wheel(int index)
    {
        string charWheel = " ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int max = charWheel.Length;
        while (index > max) index -= max;
        while (index ("less than" sign here) 0) index += max;
        return charWheel[index];
    }
Where Menu.separator is a string ": ".<br>
