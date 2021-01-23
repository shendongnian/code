    public class CustomTableCell
    {
       public TableCell Cell {get; private set;} //The open xml sdk TableCell class
       public string InnerText
       {
            get { return Cell.InnerText; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    return;
                Paragraph p = Cell.GetFirstChild<Paragraph>();
                if (p.ChildElements.Count > 1)
                {
                    Run run = (Run)p.GetFirstChild<Run>().CloneNode(true);
                    p.RemoveAllChildren<Run>();
                    run.RemoveAllChildren<Text>();
                    run.GetMultiLineRun(value);
                    p.AppendChild(run);
                }
                else
                {
                    Run run = p.GetFirstChild<Run>();
                    if (run != null)
                        run.GetMultiLineRun(value);
                    else
                    {
                        run = new Run();
                        p.Append(run.GetMultiLineRun(value));
                    }
                }
            }
        }
    }
