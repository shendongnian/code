    if (_tipo4 == "VFI")
            {
                _selectedItem = testataFatturaImmediataVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoFatturaImmediataVendita");
                newTestata = Mapper.Map<TestataFatturaImmediataVendita, TestataDocumento>(
                        (TestataFatturaImmediataVendita)_selectedItem);
            }
            if (_tipo4 == "VDT")
            {
                _selectedItem = testataDocumentoDiTrasportoRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoCorpoDocumentoDiTrasportoVendita");
                newTestata =
                    Mapper.Map<TestataDocumentoDiTrasportoVendita, TestataDocumento>(
                        (TestataDocumentoDiTrasportoVendita)_selectedItem);
            }
            if (_tipo4 == "VFD")
            {
                _selectedItem = testataFatturaDifferitaVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoFatturaDifferitaVendita");
                newTestata =
                    Mapper.Map<TestataFatturaDifferitaVendita, TestataDocumento>(
                        (TestataFatturaDifferitaVendita)_selectedItem);
            }
            if (_tipo4 == "VNG")
            {
                _selectedItem = testataNotaCreditoGenericaVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoNotaCreditoGenericaVendita");
                newTestata =
                    Mapper.Map<TestataNotaCreditoGenericaVendita, TestataDocumento>(
                        (TestataNotaCreditoGenericaVendita)_selectedItem);
            }
            if (_tipo4 == "VBU")
            {
               _selectedItem = testataBuonoDiConsegnaVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoBuonoDiConsegnaVendita");
                newTestata =
                    Mapper.Map<TestataBuonoDiConsegnaVendita, TestataDocumento>(
                        (TestataBuonoDiConsegnaVendita)_selectedItem);
            }
            if (_tipo4 == "VND")
            {
                _selectedItem = testataNotaDebitoVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoNotaDebitoVendita");
                newTestata =
                   Mapper.Map<TestataNotaDebitoVendita, TestataDocumento>(
                        (TestataNotaDebitoVendita)_selectedItem);
            }
            if (_tipo4 == "VFG")
            {
                _selectedItem = testataFatturaGenericaVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoFatturaGenericaVendita");
                newTestata =
                    Mapper.Map<TestataFatturaGenericaVendita, TestataDocumento>(
                        (TestataFatturaGenericaVendita)_selectedItem);
            }
            if (_tipo4 == "VNC")
            {
                _selectedItem = testataNotaCreditoVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoNotaCreditoVendita");
                newTestata = Mapper.Map<TestataNotaCreditoVendita, TestataDocumento>(
                        (TestataNotaCreditoVendita)_selectedItem);
            }
            if (_tipo4 == "VFA")
            {
                _selectedItem = testataFatturaAccontoVenditaRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoFatturaAccontoVendita");
                newTestata =
                    Mapper.Map<TestataFatturaAccontoVendita, TestataDocumento>(
                       (TestataFatturaAccontoVendita)_selectedItem);
            }
            if (_tipo4 == "AFI")
            {
                _selectedItem = testataFatturaImmediataAcquistoRepository.Prendi(x => x.Id == _idDocumentoRicerca, "CorpoFatturaImmediataAcquisto");
                newTestata =
                    Mapper.Map<TestataFatturaImmediataAcquisto, TestataDocumento>(
                        (TestataFatturaImmediataAcquisto)_selectedItem);
            }
