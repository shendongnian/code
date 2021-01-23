    public class ViewModel
    {
        public Content ContentInstance { get; set; }
        public int Value
        {
            get
            {
                switch (Content.Selector)
                {
                    case 1:
                        return contentPart.Value1;
                    //etc
                }
            }
            set
            {
                switch (Content.Selector)
                {
                    case 1:
                        contentPart.Value1 = value;
                        break;
                    //etc
                }
            }
        }
    }
