    public void getPicture(Repository repository)
        {
            Object item;
            ObjectType ot = repository.GetTreeSelectedItem(out item);
            Word.Application wapp = GetWordApp();
            var document = wapp.Documents.Add();
            var paragraph = document.Paragraphs.Add();
            Project project = repository.GetProjectInterface();
            if (ot == ObjectType.otDiagram)
            {
                Diagram d = (Diagram)item;
                project.PutDiagramImageOnClipboard(d.DiagramGUID, 0);
                paragraph.Range.Paste();
            }
        }
            private Word.Application GetWordApp()
        {
            Word.Application wapp = new Word.Application();
            wapp.Visible = true;
            return wapp;
        }
