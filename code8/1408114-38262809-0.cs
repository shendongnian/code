        private string fill_form(string output_file)
        {
            using (PdfReader _pdfReader = new PdfReader(FormPath))
            {
                using (PdfStamper _pdfStamper = new PdfStamper(_pdfReader, new FileStream(output_file, FileMode.Create)))
                {
                    _pdfStamper.AcroFields.GenerateAppearances = true;
                    foreach (var _field in _pdfStamper.AcroFields.Fields)
                        foreach (TemplateField _spField in _lstFields)
                        {
                            if (_field.Key.Equals(_spField.Name))
                            {
                                switch (_spField.Type )
                                {
                                    case TemplateFieldType.Text:
                                        _pdfStamper.AcroFields.SetField(_field.Key, _spField.Value);
                                        break;
                                    case TemplateFieldType.Checkbox:
                                        //TODO: check Value field cannot be set != OnValue, Offvalue
                                        if (_spField.Value == _spField.OnValue)
                                            _pdfStamper.AcroFields.SetField(_field.Key, _spField.OnValue);
                                        else
                                            _pdfStamper.AcroFields.SetField(_field.Key, _spField.OffValue);
                                        break;
                                }
                            }
                        }
                    _pdfStamper.FormFlattening = true;
                }
            }
            return output_file;
        }
