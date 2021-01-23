    public static IEnumerator DasTweeng<T>( this float duration, System.Action<T> vary, T aa, T zz )
		{
		float sT = Time.time;
		float eT = sT + duration;
		
		Func<T,T,float,T> step;
		
		if (typeof(T) == typeof(float))
			step = (Func<T,T,float,T>)(Delegate)(Func<float, float, float, float>)Mathf.SmoothStep;
    	else if (typeof(T) == typeof(Vector3))
    		step = (Func<T,T,float,T>)(Delegate)(Func<Vector3, Vector3, float, Vector3>)Vector3.Lerp;
		else
			throw new ArgumentException("Unexpected type "+typeof(T));
		
		while (Time.time < eT)
			{
			float t = (Time.time-sT)/duration;
			vary( step(aa,zz, t) );
			yield return null;
			}
		vary(zz);
		}
