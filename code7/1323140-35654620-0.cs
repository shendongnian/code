            var sw = new Stopwatch();
            int loopLimit = 10000000;
            object hint1;
            sw.Start();
            for( var i = 0; i < loopLimit; i++ )
                hint1 = ( ( dynamic )theObject ).ToString();
            sw.Stop();
            Console.WriteLine( "dynamic time: {0}", sw.ElapsedMilliseconds );
            sw.Restart();
            for( var i = 0; i < loopLimit; i++ )
                hint1 = method.Invoke( theObject, null );
            sw.Stop();
            Console.WriteLine( "invoke time: {0}", sw.ElapsedMilliseconds );
            Console.ReadLine();
