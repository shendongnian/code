    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace QTest
    {
        class nofQDo
        {
            static BlockingCollection<QDo> queue = new BlockingCollection<QDo>(new ConcurrentQueue<QDo>()); //<--new ConcurrentQueue<QDo>() makes it FIFO
    
            static nofQDo()
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (QDo doThis in queue.GetConsumingEnumerable())
                    {
                        doThis.run();
                    }
                });
            }
    
            public static void addAction(QDoType action)
            {
                QDo me = new QDo(action);
                queue.Add(me);
            }
        }
    }
