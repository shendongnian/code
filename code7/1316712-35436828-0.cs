    private void resetLineDraw()
    {
        DebugLabel.Text = "";
        pointsSelected = false;
        lineTool = false;
        numOfClicks = 0;
        // this removes the click handler from the picture box.
        // so, if you click on it anymore, nothing will happen.
        //-->  imagem.MouseClick -= imagem_MouseClick;
    }
    private void imagem_MouseClick(object sender, MouseEventArgs e)
    {
        /* Captura os pontos inicias e finais se a ferramenta de desenho 
         * de retas esta habilitada */
        if (lineTool && !pointsSelected)
        {
            // same here
            // --> if (numOfClicks == 1) imagem.MouseClick -= imagem_MouseClick; 
            Point tmp = new Point(e.X, e.Y);
            if (numOfClicks == 0)
            {//Selecionou o primeiro ponto
                lineStart = tmp;
                DebugLabel.Text = "Primeiro ponto selecionado";
            }
            else
            {//Selecionou o segundo ponto
                lineEnd = tmp;
                pointsSelected=true;
                DebugLabel.Text = "Segundo ponto selecionado";
            }
            numOfClicks++;
        }              
    }
