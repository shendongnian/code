    public class TableContratoMap : ClassMapper<TableContrato>
    {
    public TableContratoMap()
       {
           // ReSharper disable once RedundantBaseQualifier
           base.Table("Contrato");
           AutoMap();
       }
    }
