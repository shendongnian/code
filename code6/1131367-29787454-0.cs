private async Task Action()
{
    ExecuteWork(Machines.SetA);
    while (!IsWorkDone(Machines.SetA))
    {
        await Task.Delay(TimeSpan.FromMinutes(1));
    }
    ExecuteWork(Machines.SetB);
}
