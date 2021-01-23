    Range r1 = doc.Content; 
    Range r2 = doc.Content; 
    r1.Find.Execute("Heading 1"); 
    r2.Find.Execute("Heading 2");
 
    Range chapter = doc.Range(r1.Start, r2.Start); 
    //Console.WriteLine(chapter.Text);
                    
    foreach (Table t in chapter.Tables)
    {
        foreach(Row r in t.Rows)
        {
            foreach (Cell c in r.Cells)
            {
                //Console.WriteLine(c.Range.Text);
            }
        }
    }
                 
