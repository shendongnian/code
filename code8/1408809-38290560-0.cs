            Script s = new Script(CoreModules.Preset_Complete);
            DynValue dv = s.DoString(luaTable + "\nreturn DataStore_ContainersDB;");
            Table t =  dv.Table;
            Table global;
            global = t.Get("global").ToObject<Table>().Get("Characters").ToObject<Table>();
            foreach (var key in global.Keys)
            {
                Console.WriteLine( key.ToString() );
            }
