    public inteface IPerson;
    public inteface ILeader : IPerson;
    public interface ISecretary : IPerson;
    public interface IParent : IPerson;
    public Leader : ILeader;
    public Secretary : ISecretary;
    public Parent : IParent;
    public LeaderSecretary : ILeader, ISecretary;
    public LeaderParent : ILeader, IParent;
    public SecretaryParent: ISecretary, IParent,
    public LeaderSecretaryParent: ILeader, ISecretary, IParent;
