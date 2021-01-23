    [DisplayNameLocalized("Category")]
    [JqGridColumnSortable(true, Index = "CategoryPK")]
    [JqGridColumnEditable(true, "List4DDL", "Categories", EditType = JqGridColumnEditTypes.Select)]
    [JqGridColumnFormatter("$.ddlFormatter", UnFormatter = "$.ddlUnFormatter")]
    public string Category { get; set; }
