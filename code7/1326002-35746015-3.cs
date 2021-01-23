    public class MyDoc : Dictionary<string, object>
        {
            public string text
            {
                get
                {
                    object mytext;
                    return TryGetValue("text", out mytext) ? mytext.ToString() : null;
                }
                set { this.Add("text", value);}
            }
        }
