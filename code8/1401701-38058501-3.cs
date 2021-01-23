    Dim query = From row In oDT.AsEnumerable()
                Group row By Moneda = 
                New With 
                {
                    Key .CodTipoMoneda = row.Field(Of String)("CodTipoMoneda")
                } Into NameGroup = Group
                       Select New With 
                       {
                             .TipoMoneda = Moneda.CodTipoMoneda,
                             .Saldo = NameGroup.Where(Function(n) n.Field(Of Decimal)("Saldo") <> 10)
                                               .Sum(Function(r) r.Field(Of Decimal)("Saldo"))
                       }
