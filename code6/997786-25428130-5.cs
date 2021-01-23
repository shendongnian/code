            private void RadioButton(object tipoDaPeca)
            {
                if (tipoDaPeca.ToString() == EnumHelper.ObterDescricao(TipoDePeca.Bandeja))
                {
                    DevoExibirOpcoesParaPainel = false;              
                }
                else
                {
                    DevoExibirOpcoesParaPainel = true;
                }
            }
