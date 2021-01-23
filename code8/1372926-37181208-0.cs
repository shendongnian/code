     string dirPath = @"c:\mydir";        
    string[] htmlfiles = System.IO.Directory.GetFiles(dirPath, "*.HTML", SearchOption.AllDirectories);//Filter can be *.xml
            foreach (string filename in htmlfiles)
            {
                HtmlDocument document = new HtmlDocument();
    
                document.Load(filename);
    
            HtmlNodeCollection linknodes = document.DocumentNode.SelectNodes("//a");
            
                for (int i = 0; i < linknodes.Count; i++)
                {
                    HtmlNode node = linknodes[i];
                    var href = node.Attributes["href"].Value;
                    //Reassigning href value
                    node.Attributes["href"].Value ="put your replacement string";
                }
    
    
                HtmlNodeCollection imgnodes = document.DocumentNode.SelectNodes("//img");
                for (int i = 0; i < imgnodes.Count; i++)
                {
                    HtmlNode node = imgnodes[i];
                    var src = node.Attributes["src"].Value;
                    //Reassigning href value
                    node.Attributes["src"].Value = "put your replacement string";
                }
    
                document.Save(filename);
            }//end of loop all files
