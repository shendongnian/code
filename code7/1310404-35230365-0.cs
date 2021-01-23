    public class WebTile : Tile
        {
            private string html;
            public string HTML
            {
                get { return html; }
            }
            public WebTile(string name, string description, string html) : base(name, description)
            {
             //wronge
             // this.html = HTML;
             //correct
             this.html = html;
            }
        }
