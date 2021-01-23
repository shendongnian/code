	public static IEnumerator Tweeng(this float duration, System.Action<float> var, float aa, float zz)
	{
		return Tweeng(duration, var, aa, zz, Mathf.SmoothStep);
	}
	public static IEnumerator Tweeng(this float duration, System.Action<Vector3> var, Vector3 aa, Vector3 zz)
	{
		return Tweeng(duration, var, aa, zz, Vector3.Lerp);
	}
	private static IEnumerator Tweeng<T>(this float duration,
			 System.Action<T> var, T aa, T zz, Func<T,T,float,T> thing)
	{
		float sT = Time.time;
		float eT = sT + duration;
		while (Time.time < eT)
		{
			float t = (Time.time - sT) / duration;
			var(thing(aa, zz, t));
			yield return null;
		}
		var(zz);
	}
