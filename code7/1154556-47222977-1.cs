    IEnumerable<Run> runs = Paragraph.Descendants<Run>()
        .Where(el => el.InnerText.Contains("<<>>"));
    if(runs != null) {
        foreach(Run run in runs) { 
            // Use this if using powerpoint openxml
            run.Text = new Text(run.InnerText.Replace("<<>>", "your text");
            // Use this if using wordprocessing openxml
            string innerText = run.InnerText.Replace("<<>>", "your text");
            run.RemoveAllChildren<Text>();
            run.AppendChild(new Text(innerText));
        }
    }
