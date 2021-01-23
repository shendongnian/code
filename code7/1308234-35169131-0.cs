    <Page.DataContext>
        <vm:MasterViewModel x:Name="ViewModel" />
    </Page.DataContext>
    class MasterViewModel 
    {
        public ProdutoViewModel ProdutoViewModel { get; set; }
        public EncomendaProdutoViewModel EncomendaProdutoViewModel { get; set; }
    }
