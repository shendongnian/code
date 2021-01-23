    var kernel = new StandardKernel();
    kernel.Bind<ITableProvider>().ToConstant(new TableProvider());
    kernel.Bind<ITableWrapper>().ToProvider<TableWrapperProvider>();
    kernel.Get<FooTableUser>().TableWrapper.Table.Name.Should().Be(Tables.FooTable);
    kernel.Get<BarTableUser>().TableWrapper.Table.Name.Should().Be(Tables.BarTable);
