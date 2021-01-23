    protected override void Render (HtmlTextWriter writer)
        {
            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            HtmlTextWriter tw = new HtmlTextWriter(new System.IO.StringWriter(sb));
            //Render the page to the new HtmlTextWriter which actually writes to the stringbuilder
            base.Render(tw);
            //Get the rendered content
            string sContent = sb.ToString();
            string divStr = "<div id=\"LoadingSpinImage\"></div>"+Environment.NewLine+"<form ";
            //regex with firs replace
            var regex = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Escape("<form "));
            string newContent = regex.Replace(sContent, divStr, 1);
            //Now output it to the page, if you want
            writer.Write(newContent);
        }
