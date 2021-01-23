    public class BasicUnit : MonoBehaviour, IUnit {
	  [SerializeField]
	  private int		_healthPoint;
	  public int		HealthPoint 		{ get { return (_healthPoint); } set { _healthPoint = value; } }
	  [SerializeField]
	  private bool	_isIndestructible;
	  public bool		isIndestructible	{ get { return (_isIndestructible); } set { _isIndestructible = value; } }
    }
