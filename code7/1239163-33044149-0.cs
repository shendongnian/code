    this.table.Rows.Clear();//clear table
    
    //Re add headers
    this.table.Rows.Add (
        new TableHeaderRow(){ Cells = {
            new TableHeaderCell() {Text = "Id"},
            new TableHeaderCell() {Text = "Descrição"},
            new TableHeaderCell() {Text = "Arquivo"},
            new TableHeaderCell() {Text = "Tamanho"},
            new TableHeaderCell() {Text = "Ed"},
            new TableHeaderCell() {Text = "Ex"},
        }
    });
    foreach (var item in _listaArquivos) {
        var btn = new Dictionary<string,Button>();
        btn["Editar"] = new Button() {
            CausesValidation = false,
            UseSubmitBehavior = true,
            Text = "Edit",
            ID = item.Id.ToString(),
            CommandName = "edit",
            CommandArgument = item.Id.ToString(),
            CssClass = "btn btn-primary btn-xs",
        };
        btn["Excluir"] = new Button() {
            CausesValidation = false,
            UseSubmitBehavior = true,
            Text = "Excluir",
            ID = item.Id.ToString(),
            CommandName = "excluir",
            CommandArgument = item.Id.ToString(),
                CssClass = "btn btn-primary btn-xs",
        };
        //add events
        btn["Edit"].Click += new EventHandler(btnEditarArquivo_OnClick);
        btn["Exclude"].Click += new EventHandler(btnEditarArquivo_OnClick);
        this.tabelaArquivo.Rows.Add(
            new TableRow() { Cells = {
                new TableCell() {Text = item.Id.ToString()},
                new TableCell() {Text = item.Descricao},
                new TableCell() {Text = item.Arquivo},
                new TableCell() {Text = item.Tamanho},
                new TableCell() {Controls = {btn["Edit"]}},
                new TableCell() {Controls = {btn["Exclude"]}},
            },
        });
    }
