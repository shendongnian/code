    private readonly ICalculateTotalService _calculateTotalService;
    public decimal GetTotal(IOrder order)
    {
        return order.Lines.Sum(line => _calculateTotalService.GetTotal(line));
    }
