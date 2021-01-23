        public void rodarScript()
        {
            try
            {
                //PARTE PARA ADICIONAR BIBLIOTECAS BASICAS PARA DESENVOLVIMENTO COM OS SCRIPTS
                script = @"#...";
                this.Dispatcher.Invoke((Action)(() =>
                {
                    script = script + "\n" + textBoxScript.Text;
                }));
                var source = engine.CreateScriptSourceFromString(script, SourceCodeKind.Statements);
                //var compiled = source.Compile();
                //var result = compiled.Execute(scope);
                source.Execute(scope);
            }
            catch (Exception qualquerExcecaoEncontrada)
            {
                MessageBox.Show(qualquerExcecaoEncontrada.ToString(), "Scripting Test do Mier", MessageBoxButton.OK);
            }
        }
