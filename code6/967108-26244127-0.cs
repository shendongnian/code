                foreach (ReportViewer r in ListaReportes)
                {
                    ContentPresenter Presenter = new ContentPresenter();
                    Presenter.Width = 200;
                    Presenter.Height = 260;
                    WindowsFormsHost Host = new WindowsFormsHost();
                    Host.Child = r;
                    Presenter.Content = Host;
                    Miniaturas.Children.Add(Presenter);
                    r.RefreshReport();
                } 
