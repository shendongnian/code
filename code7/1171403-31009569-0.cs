    // here's the solution thanks to jdweng and Tim - I adjusted it to work with 5 columns based on 3 columns.
    var result = toDisplay.AsEnumerable()
                 .GroupBy(x => new { Col1 = x.Field<string>("rItem"),
                                     Col2 = x.Field<string>("rMaterial"),
                                     Col3 = x.Field<string>("rSpecs")})
                .Select(g => new
                {
                    Col1 = g.Key.Col1,
                    Col2 = g.Key.Col2,
                    Col3 = g.Key.Col3,
                    Col4 = String.Join(", ", g.Select(row => row.Field<string>("rQuantity"))),
                    Col5 = String.Join(", ", g.Select(row => row.Field<string>("rOptional"))),
                });
