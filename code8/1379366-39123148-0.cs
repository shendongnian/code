    Paragraph res = new Paragraph(
    new Hyperlink(new ProofError() { Type = ProofingErrorValues.GrammarStart },
                                 new Run(
                                     new RunProperties(
                                     new RunStyle() { Val = "Hyperlink" }
                                     ),
                                     new Text("Text")
                                 )
                                 { RsidRunProperties = uniqueId},
                                 new ProofError() { Type = ProofingErrorValues.GrammarEnd }
                                 )
                             {
                                 Id = relationid,
                                 History = new DocumentFormat.OpenXml.OnOffValue(true)
                             }
    )
