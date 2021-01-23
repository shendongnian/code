    public class RunInfo
    {
        public string Content { get; set;}
        public Color foreground { get; set; }
        public RunInfo(string content)
        {
            Content = content;
        }
        public Run AsRun()
        {
           return new Run(Content){ Foreground = foreground };
        }
 
    }
    public static class Syntax
    {
        static Regex subFormula = new Regex(@"\w+\(\)");
        static Regex sapFormula = new Regex(@"\w+\(([^)]+)\)");
        static Regex strings = new Regex(@"\'[^']+\'");
        static Regex numerals = new Regex(@"\b[0-9\.]+\b");
        static Regex characteristic = new Regex(@"(?:)?\w+(?:)?");
        static Regex andOr = new Regex(@"( and )|( AND )|( or )|( OR )");
        static Regex not = new Regex(@"(not )|(NOT )");
    
        private static Brush[] colorArray;
    
        public static List<RunInfo> Highlight(String input)
        {
    
    
            colorArray = new Brush[input.Length];
    
            for (int i = 0; i < input.Length; i++)
                colorArray[i] = Brushes.Black;
    
            //Reihenfolge beibehalten!!
            assignColor(Brushes.Blue, characteristic.Matches(input));
            assignColor(Brushes.Black, andOr.Matches(input));
            assignColor(Brushes.Black, numerals.Matches(input));
            assignColor(Brushes.Orange, strings.Matches(input));
            assignColor(Brushes.DeepPink, subFormula.Matches(input));
            assignColor(Brushes.Green, sapFormula.Matches(input));
            assignColor(Brushes.Green, not.Matches(input));
    
    
            int index = 0;
    
            List<Run> runList = new List<Run>();
    
            foreach (Char character in input)
            {
    
                runList.Add(new RunInfo(character.ToString()) { Foreground = colorArray[index] });
                index++;
            }
    
    
            colorArray = null;
            return runList;
        }
    
        public static void Check(TextBlock textBlock)
        {
    
        }
    
    
        private static void assignColor(Brush brush, MatchCollection matchCollection)
        {
            foreach (Match match in matchCollection)
            {
                int start = match.Index;
                int end = start + match.Length;
    
                for (int i = start; i < end; i++)
                {
                    colorArray[i] = brush;
                }
            }
        }
    }
    private void syntaxWorker_DoWork(object sender, DoWorkEventArgs e)
    {
    	if (e.Argument == null)
    		Thread.Sleep(100);
    	else
    	{
    		Dictionary<TextBlock, String> dic = (Dictionary<TextBlock, String>)e.Argument;
    
    		foreach (KeyValuePair<TextBlock, String> kvp in dic)
    		{
    			//i am unsure if this line will work. if it does not, you might need to do a separate dispatcher invoke in order to retreive the text from the textbox.
    			List<RunInfo> runinfoObjects = Syntax.Highlight(kvp.Value); 
    			kvp.Key.Dispatcher.BeginInvoke(new Action(() => 
    			{
    				kvp.Key.Inlines.Clear();
                    //we'd run into problems here, since wpf won't allow us to add elements created in a background thread. since we now make the Run object inside the invoke, we should be fine.
    				runinfoObjects.ForEach(x => kvp.Key.Inlines.Add(x.AsRun()));
    			}));
    		}
    	}
    }
