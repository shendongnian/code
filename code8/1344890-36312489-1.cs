    public class avg_acc
    {
        public int count;
        public double sum;
    }
    public double ParallelAverage(IEnumerable<double> list)
    {
        double avg = list.AsParallel().Aggregate(
            // accumulator factory method, called once per thread:
            () => new avg_acc { count = 0, sum = 0 },
            // update count and sum
            (acc, val) => { acc.count++; acc.sum += val; return acc; },
            // combine accumulators
            (ac1, ac2) => new avg_acc { count = ac1.count + ac2.count, sum = ac1.sum + ac2.sum },
            // calculate average
            acc => acc.sum / acc.count
        );
        return avg;
    }
