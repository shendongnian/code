    DataTable filteredEducation = dt1.AsEnumerable()
              .Where(x => dt.AsEnumerable()
              .Any(z => z.Field<string>("Email").Trim().Equals(x.Field<string>("Email").Trim(),StringComparison.CurrentCultureIgnoreCase)))
              .CopyToDataTable();
        DataTable filteredEmployee = dt2.AsEnumerable()
              .Where(x => dt.AsEnumerable()
              .Any(z => z.Field<string>("Email").Trim().Equals(x.Field<string>("Email").Trim(),StringComparison.CurrentCultureIgnoreCase)))
              .CopyToDataTable();
