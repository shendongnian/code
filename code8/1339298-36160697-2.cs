     private void BuscarSelecionados()
        {
            foreach (TreeNode tN in tvDiretorios2.SelectedNodes)
            {
                MessageBox.Show(tN.FullPath.ToString(), "Atenção");
            }
        }
