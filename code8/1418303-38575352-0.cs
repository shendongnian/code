    //Create a test file on our desktop
    var testFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    //Possible styles
    var styles = new Dictionary<string, int>() {
        { "NORMAL" , iTextSharp.text.Font.NORMAL },
        { "BOLD" , iTextSharp.text.Font.BOLD },
        { "ITALIC" , iTextSharp.text.Font.ITALIC },
        { "UNDERLINE" , iTextSharp.text.Font.UNDERLINE },
        { "STRIKETHRU",  iTextSharp.text.Font.STRIKETHRU }
    };
    
    //Standard iText bootstrap
    using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using(var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
                //We're going to try every possible unique combination of constants, store the
                //previously used ones in this dictionary
                var used = new Dictionary<int, string>();
                
                //Fixed-number combination hack, just create 5 nested loops.
                foreach (var a in styles) {
                    foreach (var b in styles) {
                        foreach (var c in styles) {
                            foreach (var d in styles) {
                                foreach (var g in styles) {
                                    //Bitwise OR the values together
                                    var k = a.Value | b.Value | c.Value | d.Value | g.Value;
                                    //If we didn't previously use this OR'd value
                                    if (!used.ContainsKey(k)) {
                                        //Get all of the unique names exclude duplicates
                                        var names = new string[] { a.Key, b.Key, c.Key, d.Key, g.Key }.Distinct().OrderBy(s => s).ToList();
                                        //NORMAL is the "default" and although NORMAL | BOLD is totally valid it just
                                        //messes with your brain when you see it. So remove NORMAL from the description
                                        //when it is used with anything else. This part is optional
                                        if (names.Count() > 1 && names.Contains("NORMAL")) {
                                            names = names.Where(n => n != "NORMAL").ToList();
                                        }
                                        //Merge our names into a comma-separated string
                                        var v = String.Join(", ", names);
                                        //Store it so we don't use it again
                                        used.Add(k, v);
                                        //Create a font using this loop's value
                                        var myFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, k, BaseColor.BLACK);
                                        //Add it to our document
                                        doc.Add(new Paragraph(k.ToString() + "=" + v, myFont));
                                    }
                                }
                            }
                        }
                    }
                }
                doc.Close();
            }
        }
    }
