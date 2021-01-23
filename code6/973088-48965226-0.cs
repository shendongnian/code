    public int solution(int[] A)
    {
        var numbers = Enumerable.Range(1, Math.Abs(A.Max())+1).ToArray();
        return numbers.Except(A).ToArray()[0];
    }
