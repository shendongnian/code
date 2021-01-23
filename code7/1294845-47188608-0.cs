    public class ButtonAsLink : Button
    {
        Button myButtonLink;
        public Button Create()
        {
            if(myButtonLink == null)
            {
                myButtonLink = new Button()
                {
                    TextColor = Color.Blue,
                    BackgroundColor = Color.Transparent,
                    BorderWidth = 0
                };
            }
            return myButtonLink;
        }
    }
