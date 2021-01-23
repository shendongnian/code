        private void tvDiretorios2_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //pega os Selecionados e colocar em uma lista
            List<string> listaSelecionados = new List<string>();
            foreach (TreeNode tN in tvDiretorios.SelectedNodes)
            {
                listaSelecionados.Add(tN.FullPath.ToString());
            }
            DoDragDrop(listaSelecionados, DragDropEffects.Move);
        }
        private void tvDiretorios2_DragOver(object sender, DragEventArgs e)
        {
            //Depois de DoDragDrop Existi- 2°Passo. Confirma que o que foi puxado é uma lista
            if (e.Data.GetDataPresent(typeof(List<string>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        /** EVENTOS DROP DA LISTA */
        private void lbConvertidas_DragEnter(object sender, DragEventArgs e)
        {
            //Determina se o o objeto pode ser arrastado para o lbConvertidas
            if(e.Data.GetDataPresent(typeof(List<string>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void lbConvertidas_DragDrop(object sender, DragEventArgs e)
        {
            //Toma alguma ação quando ele for solto
            //Importar(); -- Ação Principal
            var lista = e.Data.GetData(typeof(List<string>)) as List<string>;
            if (lista != null)
                lbConvertidas.Items.AddRange(lista.ToArray()); //será convertido 
        }
