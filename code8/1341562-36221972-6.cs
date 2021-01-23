    List<Row> list;
    using (IEnumerator<Row> enumerator = table.GetEnumerator())
    {
        list = (List<Row>)typeof(List<Row>.Enumerator)
            .GetField("list", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(enumerator);
    }
