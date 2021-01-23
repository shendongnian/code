    public class MyEnityMap : ClassMapping<MyEnity>
    {
        public MyEnityMap()
        {
            Table("my_entity");
            Id(p => p.myId,
               m=>{
                   m.Column("my_id");
                   m.Generator(new NextIdGeneratorDef(), g =>g.Params( new
                   {
                       table = "sys_params",
                       column = "param_nextvalue",
                       where = "table_name = 'my_entity'"
                   }));
               });
            .......                   
        }
    }
