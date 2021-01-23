        DataTable table11 = new DataTable();
        table11.Columns.Add("ID", typeof(int));
        table11.Columns.Add("Weight", typeof(int));
        table11.Columns.Add("Name", typeof(string));
        table11.Columns.Add("Breed", typeof(string));
        table11.Rows.Add(23, 57, "Koko", string.Empty);
        table11.Rows.Add(44, 130, "Fido", null);
        table11.Rows.Add(54, 130, "Jack", null);
        table11.Rows.Add(44, 130, "Thad", null);
        table11.Rows.Add(64, 130, "John", null);
        table11.Rows.Add(23, 130, "Brian", null);
        table11.Rows.Add(445, 130, "James", null);
        table11.Rows.Add(64, 134, "Adam", null);
       var duplicate = table1.AsEnumerable()
           .Select(dr => dr.Field<int>("ID"))
           .GroupBy(x => x)
           .Where(g => g.Count() > 1)
           .Select(g => g.Key)
           .ToList();
       var duplicate2 = table1.AsEnumerable()
           .Select(dr => dr.Field<int>("Weight"))
           .GroupBy(x => x)
           .Where(g => g.Count() > 1)
           .Select(g => g.Key)
           .ToList();
