    public class CronTab
    {
        public CronType type;
        public Action action;
    }
    public static void addEnergy(DateTime date)
    {
        if (PlayerInfo.Instance.Energy < PlayerInfo.Instance.MaxEnergy)
            PlayerInfo.Instance.Energy++;
        date = date.AddSeconds(10);
        PlayerInfo.Instance.cron.Add(
            new KeyValuePair<DateTime, CronTab>(
                date,
                new CronTab()
                {
                    type = CronType.energy,
                    action = () => PlayerInfo.addEnergy(date),
                }));
    }
