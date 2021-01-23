    public class Producer {
        private BlockingCollection queue;
        public Producer(BlockingCollection queue) {
            this.queue = queue;
        }
        // more code...
    }
    public class Consumer {
        private BlockingCollection queue;
        public Consumer(BlockingCollection queue) {
            this.queue = queue;
        }
        // more code...
    }
    // The exact design of this class is up to you. This is just an example.
    public class ProducerConsumerBuilder {
        public void BuildProducerAndConsumer(out Producer producer, out Consumer consumer) {
            BlockingCollection queue = new BlockingCollection();
            producer = new Producer(queue);
            consumer = new Consumer(queue);
            // No need to save a reference to "queue" here any longer,
            // unless you need it for something else.
            // It's enough that the producer and consumer each
            // hold their own private reference to the same queue.
        }
    }
