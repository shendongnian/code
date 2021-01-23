    public class CustomLabel : Label
    {
        public override String Text
        {
            get
            {
                ModeType mode = this.Context.Session["Mode"];
                if (mode == ModeType.People)
                {
                    return "People";
                }
                else
                {
                    return "Community";
                }
            }
            set
            {
                throw new NotSupportedException(); 
            }
        }
    }
