    public class Enemy:BaseFrite
    	{
    	public tk2dSpriteAnimator animMain;
    	public string usualAnimName;
    	
    	[System.NonSerialized] public Enemies boss;
    	
    	[Header("For this particular enemy class...")]
    	public float typeSpeedFactor;
    	public int typeStrength;
    	public int value;
    	
    	// could be changed at any time during existence of an item!
    	
    	[System.NonSerialized] public FourLimits offscreen;	// must be set by our boss
    	
    	[System.NonSerialized] public int hitCount;			// that's ATOMIC through all integers
    	[System.NonSerialized] public int strength;			// just as atomic!
    	
    	[System.NonSerialized] public float beginsOnRight;
    	
    	private bool inPlay;	// ie, not still in runup
    	
    	void Awake()
    		{
    		boss = Gp.enemies;
    		}
    	
    ..........
    
    	protected virtual void Prepare()	// write it for this type of sprite
    		{
    		ChangeClipTo(bn);
    		// so, for the most basic enemy, you just do that.
    		// for other enemy, that will be custom (example, swap damage sprites, etc)
    		}
    	
    	void OnTriggerEnter2D(Collider2D c)
    		{
    		// we can ONLY touch either Biff or a projectile. to wit: layerBiff, layerPeeps
    		
    		GameObject cgo = c.gameObject;
    		
    		if ( gameObject.layer != Grid.layerEnemies ) // if we are not enemy layer....
    			{
    			Debug.Log("SOME BIZARRE PROBLEM!!!");
    			return;
    			}
    		
    		if (cgo.layer == Grid.layerBiff)	// we ran in to Biff
    			{
    			Gp.billy.BiffBashed();
    			// if I am an enemy, I DO NOT get hurt by biff smashing in to me.
    			return;
    			}
    		
    		if (cgo.layer == Grid.layerPeeps)	// we ran in to a Peep
    			{
    			Projectile p = c.GetComponent<Projectile>();
    			if (p == null)
    				{
    				Debug.Log("WOE!!! " +cgo.name);
    				return;
    				}
    			int damageNow = p.damage;
    			Hit(damageNow);
    			return;
    			}
    		
    		Debug.Log("Weirded");
    		}
    	
    	public void _stepHit()
    		{
    		if ( transform.position.x > beginsOnRight ) return;
    		
    		++hitCount;
    		--strength;
    		ChangeAnimationsBasedOnHitCountIncrease();
    		// derived classes write that one.
    		
    		if (strength==0)	// enemy done for!
    			{
    			Gp.coins.CreateCoinBunch(value, transform.position);
    			FinalEffect();
    			
    			if ( Gp.superTest.on )
    				{
    				Gp.superTest.EnemyGottedInSuperTest(gameObject);
    				boss.Done(this);
    				return;
    				}
    			
    			Grid.pops.GotEnemy(Gp.run.RunDistance);		// basically re meters/achvmts
    			EnemyDestroyedTypeSpecificStatsEtc();		// basically re achvments
    			Gp.run.runLevel.EnemyGotted();				// basically run/level stats
    			
    			boss.Done(this);							// basically removes it
    			}
    		}
    	
    	protected virtual void EnemyDestroyedTypeSpecificStatsEtc()
    		{
    		// you would use this in derives, to mark/etc class specifics
    		// most typically to alert achievements system if the enemy type needs to.
    		}
    	
    	private void _bashSound()
    		{
    		if (Gp.biff.ExplodishWeapon)
    			Grid.sfx.Play("Hit_Enemy_Explosive_A", "Hit_Enemy_Explosive_B");
    		else
    			Grid.sfx.Play("Hit_Enemy_Non_Explosive_A", "Hit_Enemy_Non_Explosive_B");
    		}
    	
    	public void Hit(int n)	// note that hitCount is atomic - hence strength, too
    		{
    		for (int i=1; i<=n; ++i) _stepHit();
    		
    		if (strength > 0) // biff hit the enemy, but enemy is still going.
    			_bashSound();
    		}
    	
    	protected virtual void ChangeAnimationsBasedOnHitCountIncrease()
    		{
    		// you may prefer to look at either "strength" or "hitCount"
    		}
    	
    	protected virtual void FinalEffect()
    		{
    		// so, for most derived it is this standard explosion...
    		Gp.explosions.MakeExplosion("explosionC", transform.position);
    		}
    	
    	public void Update()
    		{
    		if (!holdMovement) Movement();
    		
    		if (offscreen.Outside(transform))
    			{
    			if (inPlay)
    				{
    				boss.Done(this);
    				return;
    				}
    			}
    		else
    			{
    			inPlay = true;
    			}
    		}
    	
    	protected virtual void Movement()
    		{
    		transform.Translate( -Time.deltaTime * mpsNow * typeSpeedFactor, 0f, 0f, Space.Self );
    		}
    ......
    
    
    
    /*
    (frite - flying sprite)
    The very base for enemies, projectiles etc.
    */
    
    using UnityEngine;
    using System.Collections;
    
    public class BaseFrite:MonoBehaviour
    	{
    	[System.NonSerialized] public float mpsNow;
    	// must be set by the boss (of the derive) at creation of the derive instance!
    	
    	private bool _paused;
    	public bool Paused
    		{
    		set {
    			if (_paused == value) return;
    			
    			_paused = value;
    			
    			holdMovement = _paused==true;
    			
    			if (_paused) OnGamePause();
    			else OnGameUnpause();
    			}
    		get { return _paused; }
    		}
    	
    	protected bool holdMovement;
    	
    	protected virtual void OnGamePause()
    		{
    		}
    	protected virtual void OnGameUnpause()
    		{
    		}
    	
    	protected string bn;
    	public void SetClipName(string clipBaseName)
    		{
    		bn = clipBaseName;
    		}
    	
    	}
