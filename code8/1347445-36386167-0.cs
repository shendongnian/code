    using UnityEngine;
    using System;
    using System.Reflection;
    using NUnit.Framework;
    
    public interface IWeapon
    {
        void ShootAt(GameObject target);
    }
    
    public class Rifle : MonoBehaviour, IWeapon
    {
        public void ShootAt(GameObject target)
        {
            Debug.Log("Rifle");
        }
    }
    
    public class Shotgun : MonoBehaviour, IWeapon
    {
        public void ShootAt(GameObject target)
        {
            Debug.Log("Shotgun");
        }
    }
    
    public class WeaponTests
    {
        private GameObject Shooter()
        {
            var foo = new GameObject();
            foo.AddComponent<Shotgun>();
            foo.AddComponent<Rifle>();
            return foo;
        }
    
        private MethodInfo method = null;
        private IWeapon GetWeaponByName(GameObject shooter, string name)
        {
            if (method == null)
            {
                // This is slow, cache the result
                method = typeof(GameObject).GetMethod("GetComponent", new Type[] {});
            }
            if (name == "Rifle")
            {
                MethodInfo specific = method.MakeGenericMethod(typeof(Rifle));
                return specific.Invoke(shooter, null) as IWeapon;
            }
            else if (name == "Shotgun")
            {
                MethodInfo specific = method.MakeGenericMethod(typeof(Shotgun));
                return specific.Invoke(shooter, null) as IWeapon;
            }
            return null;
        }
    
        [Test]
        public void TestGetWeaponByName()
        {
            var target = new GameObject();
            var fixture = Shooter();
            IWeapon weapon;
    
            weapon = GetWeaponByName(fixture, "Rifle");
            Assert.True(weapon != null);
            weapon.ShootAt(target);
    
            weapon = GetWeaponByName(fixture, "Shotgun");
            Assert.True(weapon != null);
            weapon.ShootAt(target);
    
            weapon = GetWeaponByName(fixture, "Laster");
            Assert.True(weapon == null);
        }
    }
