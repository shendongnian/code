            var queue = new LimitedQueue<float>(4);
            
            queue.Enqueue(52.501280f);
            var avg1 = queue.Average(); //52.50128
            queue.Enqueue(52.501350f);
            var avg2 = queue.Average(); //52.5013161
            queue.Enqueue(52.501140f);
            var avg3 = queue.Average(); //52.50126
            queue.Enqueue(52.501022f);
            var avg4 = queue.Average(); //52.5011978
            queue.Enqueue(52.501635f);
            var avg5 = queue.Average(); //52.50129
            queue.Enqueue(52.501500f);
            var avg6 = queue.Average(); //52.5013237
            queue.Enqueue(52.501505f);
            var avg7 = queue.Average(); //52.5014153
            queue.Enqueue(52.501230f);
            var avg8 = queue.Average(); //52.50147
