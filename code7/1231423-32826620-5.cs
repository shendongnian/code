    static void LateBound20(string server) {
        Type catt = Type.GetTypeFromProgID("COMAdmin.COMAdminCatalog");
        object cat = Activator.CreateInstance(catt);
        cat.GetType().InvokeMember("Connect", BindingFlags.InvokeMethod, null,
            cat, new object[] { server });
        object coll = cat.GetType().InvokeMember("GetCollection", BindingFlags.InvokeMethod, null,
            cat, new object[] { "Applications" });
        coll.GetType().InvokeMember("Populate", BindingFlags.InvokeMethod, null,
            coll, new object[] { });
        object iter = coll.GetType().InvokeMember("_NewEnum", BindingFlags.InvokeMethod, null,
            coll, new object[] { });
        System.Collections.IEnumerator iter1 = (System.Collections.IEnumerator)iter;
        while (iter1.MoveNext()) {
            object app = iter1.Current;
            object name = app.GetType().InvokeMember("Name", BindingFlags.GetProperty, null,
                app, new object[] { });
            object key = app.GetType().InvokeMember("Key", BindingFlags.GetProperty, null,
                app, new object[] { });
            Console.WriteLine(name.ToString());
            object comps = coll.GetType().InvokeMember("GetCollection", BindingFlags.InvokeMethod, null,
                coll, new object[] { "Components", key });
            comps.GetType().InvokeMember("Populate", BindingFlags.InvokeMethod, null,
                comps, new object[] { });
            object iter2 = comps.GetType().InvokeMember("_NewEnum", BindingFlags.InvokeMethod, null,
                comps, new object[] { });
            System.Collections.IEnumerator iter3 = (System.Collections.IEnumerator)iter2;
            while (iter3.MoveNext()) {
                object comp = iter3.Current;
                object cname = comp.GetType().InvokeMember("Name", BindingFlags.GetProperty, null,
                    comp, new object[] { });
                object ckey = comp.GetType().InvokeMember("Key", BindingFlags.GetProperty, null,
                    comp, new object[] { });
                Console.WriteLine("  {0} - {1}", cname, ckey);
            }
        }
    }
