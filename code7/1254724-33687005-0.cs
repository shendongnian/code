        //This code works for me
        
        @(Html.Kendo().Grid<DemoKendoScheduler.Models.DateParsing>()
               .Name("GTDGoods")
               .ToolBar(toolbar => { toolbar.Create(); })
               .Columns(columns =>
        {
            columns.Bound(p => p.GTD_ID).Hidden()
           .ClientTemplate("#= GTD_ID #" +
           "<input type='hidden' name='#= GTD_ID#' value='#= GTD_ID #'  />");
        
            columns.Bound(p => p.GOOD_NO)
            .ClientTemplate("#= GOOD_NO #" +
            "<input type='hidden' name='#= GOOD_NO#' value='#= GOOD_NO #'/>");
        
            columns.Bound(p => p.DATE)
            .ClientTemplate("#=kendo.toString(kendo.parseDate(DATE), 'dd.MM.yyyy') #" +
            "<input type='hidden' name='#= DATE#]' value='#= kendo.toString(kendo.parseDate(DATE), 'dd.MM.yyyy') #'/>");
        
            columns.Command(command => { command.Destroy(); });
        
        })
        .Editable(editable => editable.Mode(GridEditMode.InCell)
        .CreateAt(GridInsertRowPosition.Bottom))
        .DataSource(dataSource => dataSource.Ajax()
                    .Model(model =>
                    {
                        model.Id(u => u.GTD_ID);
                        //model.Field(u => u.GTD_ID);
                    })
        .ServerOperation(false)))
    
    //Model
     public class DateParsing
        {
            public int GTD_ID { get; set; }
            public string GOOD_NO { get; set; }
            [UIHint("Date")]
            public DateTime DATE { get; set; }
        }
