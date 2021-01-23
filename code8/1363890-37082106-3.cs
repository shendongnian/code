    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var structure = new Structure();
                var protein = new Protein("F", "B", 0.5F);
                protien.ApplyToStructure(structure);
            }
        }
        public class Protein
        {
            private readonly float _value;
            private readonly ProteinProperty _proteinProperty;
            private readonly ProteinType _proteinType;
            public Protein(string propertyAmino, string typeAmino, float value)
            {
                _proteinProperty = ProteinProperty.FromAmino(propertyAmino);
                _proteinType = ProteinType.FromAmino(typeAmino);
                _value = value;
            }
            public void ApplyToStructure(Structure structure)
            {
                _proteinProperty.ApplyToStructure(structure, _value);
                _proteinType.ApplyToStructure(structure, _value);
            }
        }
        public class Structure
        {
            public float Size { get; set; }
            public float Id { get; set; }
        }
        public abstract class ProteinType
        {
            private static readonly Dictionary<string, ProteinType> AllProteinTypes = typeof (ProteinType)
                .GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(nestedType => typeof (ProteinType).IsAssignableFrom(nestedType))
                .Select(nestedType => (ProteinType) Activator.CreateInstance(nestedType))
                .ToDictionary(proteinType => proteinType.Amino);
            public static ProteinType FromAmino(string amino)
            {
                ProteinType proteinType;
                if (!AllProteinTypes.TryGetValue(amino, out proteinType))
                {
                    throw new ArgumentException("Invalid amino");
                }
                return proteinType;
            }
            public abstract string Amino { get; }
            public abstract void ApplyToStructure(Structure structure, float value);
            private sealed class StructuralProteinType : ProteinType
            {
                public override string Amino { get; } = "A";
                public override void ApplyToStructure(Structure structure, float value)
                {
                    // do what you need to do to Structure
                }
            }
            private sealed class NeuralProteinType : ProteinType
            {
                public override string Amino { get; } = "B";
                public override void ApplyToStructure(Structure structure, float value)
                {
                    // do what you need to do to Structure
                }
            }
        }
        public abstract class ProteinProperty
        {
            private static readonly Dictionary<string, ProteinProperty> AllProteinProperties = typeof(ProteinProperty)
                .GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(nestedType => typeof(ProteinProperty).IsAssignableFrom(nestedType))
                .Select(nestedType => (ProteinProperty)Activator.CreateInstance(nestedType))
                .ToDictionary(proteinProperty => proteinProperty.Amino);
            public static ProteinProperty FromAmino(string amino)
            {
                ProteinProperty proteinProperty;
                if (!AllProteinProperties.TryGetValue(amino, out proteinProperty))
                {
                    throw new ArgumentException("Invalid amino");
                }
                return proteinProperty;
            }
            public abstract string Amino { get; }
            public abstract void ApplyToStructure(Structure structure, float value);
            private sealed class SizeProteinProperty : ProteinProperty
            {
                public override string Amino { get; } = "F";
                public override void ApplyToStructure(Structure structure, float value)
                {
                    structure.Size += value;
                }
            }
            private sealed class IdProteinProperty : ProteinProperty
            {
                public override string Amino { get; } = "K";
                public override void ApplyToStructure(Structure structure, float value)
                {
                    // do what you need to do to Structure
                }
            }
        }
    }
