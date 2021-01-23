    public static void GenerateRDLC(List<Tuple<string, Func<IEnumerable>>> listaDataSourcesYFuncGetDataForDataSources)
        {
                // *** code ommitted ***
                foreach (var tuplaDataSourceYFunc in listaDataSourcesYFuncGetDataForDataSources)
                {
                    var dataSourceName = tuplaDataSourceYFunc.Item1;
                    var funcGetDataForDataSources = tuplaDataSourceYFunc.Item2;
                    if (funcGetDataForDataSources != null)
                    {
                        var listaDatos = funcGetDataForDataSources();
                        renderer.ReportInstance.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(dataSourceName, listaDatos));
                    }
                }
                // *** code ommitted ***            }
        }
