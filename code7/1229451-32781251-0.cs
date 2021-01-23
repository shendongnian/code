     using (WordprocessingDocument doc = WordprocessingDocument.Open(document, true))
                        {
                           
                            MainDocumentPart parteDocumento = doc.MainDocumentPart;
        
                            foreach (SdtElement objeto in parteDocumento.Document.Descendants<SdtElement>().ToList())
                            {
    
                            foreach (Text t in objeto.Descendants<Text>().ToList())
                            {
                                
                                if (t.Text == "nombre")
                                {
                                    t.Text = persona.nombre;
                                }
                                if (t.Text == "primerApellido")
                                {
                                    t.Text = persona.primerApellido;
                                }
                                if (t.Text == "segundoApellido")
                                {
                                    t.Text = persona.segundoApellido;
                                }
                                if (t.Text == "nacionalidad")
                                {
                                    t.Text = persona.nacionalidad;
                                }
                               
                            }
                            
                            }
                        parteDocumento.Document.Save();
                        }
