    using UnityEngine;
    
    public abstract class Character : MonoBehaviour
    {
    	public int HitPoints { get; set; }
    
    	public virtual void ChangeHP(int amount)
    	{
    		HitPoints += amount;
    	}
    
    	void OnCollisionEnter(Collision other)
    	{
    		if (other.gameObject.CompareTag("DeathTrigger"))
    		{
    			Die();
    		}
    	}
    
    	protected virtual void Die()
    	{
    		Debug.Log("I'm dead.");
    	}
    }
    
    public class LordOfTerror : Character
    {
    	protected override void Die()
    	{
    		base.Die();
    		Debug.Log("But I also come back from the dead very soon.");
    		HitPoints = 100;
    	}
    }
