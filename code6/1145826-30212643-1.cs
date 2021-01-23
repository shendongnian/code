    static void Main(string[] args)
            {
                try
                {
                    string rootXml = "<Root><Connection ConnectionID=\"106359\" From_PhraseID=\"1\" To_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\"></Connection><Connection ConnectionID=\"106360\" From_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\" To_PhraseID=\"tg0if2-jc8-k6i-spg-2tof46ftr_nl\"></Connection><Connection ConnectionID=\"106361\" From_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\" To_PhraseID=\"4trq50-2h0-kqc-9ku-bm8f4cte7_nl\"></Connection><Connection ConnectionID=\"106362\" From_PhraseID=\"tg1c8p-jgg-dbh-b4l-hir5cpla7_nl\" To_PhraseID=\"1fpspg-tmq-7ln-a9b-3mr3962ca_nl\"></Connection><Connection ConnectionID=\"106358\" From_PhraseID=\"tg0if2-jc8-k6i-spg-2tof46ftr_nl\" To_PhraseID=\"jmrgi1-dst-kt6-roo-lrahuk6tj_nl\"></Connection><Connection ConnectionID=\"106373\" From_PhraseID=\"4trq50-2h0-kqc-9ku-bm8f4cte7_nl\" To_PhraseID=\"97bngg-ggb-k8l-ggf-qnre46ckq_nl\"></Connection><Connection ConnectionID=\"106376\" From_PhraseID=\"1fpspg-tmq-7ln-a9b-3mr3962ca_nl\" To_PhraseID=\"bqgccm-55n-iur-061-27obhegve_nl\"></Connection></Root>";
    
                    XElement root = XElement.Load((new StringReader(rootXml)), LoadOptions.None);
    
                    root.Descendants().Where(i => i.Attribute("To_PhraseID").Value == "tg1c8p-jgg-dbh-b4l-hir5cpla7_nl")
                                        .ToList()
                                        .ForEach(i => i.SetAttributeValue("To_PhraseID", "MYNEWID"));
    
                    var x = root.ToString();
                }
                catch (Exception ex)
                {
                    
                }
            }
