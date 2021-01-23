    public void PrintId(PdfArray Id)
    {
        if (Id != null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("ID: ");
            foreach (PdfObject o in Id)
            {
                builder.Append("<");
                foreach (byte b in ((PdfString)o).GetBytes())
                    builder.AppendFormat("{0:X}", b);
                builder.Append(">");
            }
            Console.WriteLine(builder.ToString());
        }
    }
